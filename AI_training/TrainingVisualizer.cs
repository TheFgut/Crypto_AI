using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using CryptoAnalizerAI.AI_training.dataset_loading;

namespace CryptoAnalizerAI.AI_training
{
    public class TrainingVisualizer
    {
        private CurrentErrorDisplay currentError;
        private DatasetPositionDisplay positionDisp;
        private AverageAndHighestError averageAndHighestErrDisp;
        public TrainingVisualizer(PictureBox CurrentErrorDisplayPicture,TextBox averageErrorValueBox, TextBox highestErrTextBox, PictureBox learnPosGraphic, AI_Trainer trainer)
        {
            currentError = new CurrentErrorDisplay(CurrentErrorDisplayPicture);
            averageAndHighestErrDisp = new AverageAndHighestError(averageErrorValueBox, highestErrTextBox);
            trainer.predictionEvent_retDif += currentError.Update;
            trainer.predictionEvent_retDif += averageAndHighestErrDisp.Update;
            positionDisp = new DatasetPositionDisplay(learnPosGraphic,  trainer.datasetManager);

        }

        private class CurrentErrorDisplay
        {
            private PictureBox disp;
            private int width;
            private int heigth;
            private int HalfHeigth;

            private Graphics graphics;


            public CurrentErrorDisplay(PictureBox disp)
            {

                this.disp = disp;
                width = disp.Size.Width;
                heigth = disp.Size.Height;
                HalfHeigth = heigth / 2;
                graphics = disp.CreateGraphics();
            }

            private const float scale = 5000;

            public void Update(float[] AI_output, float[] realCourse)
            {
                int l = AI_output.Length;
                float average = getAverage(realCourse);
                graphics.Clear(Color.White);

                Pen AI_pen = new Pen(Color.Green,1);
                Point[] outputPoints = new Point[AI_output.Length];
                for (int i = 0; i < outputPoints.Length; i++)
                {
                    outputPoints[i] = new Point( (int)((i/(float)l) * width), (int)(-(AI_output[i] - average) * scale) + HalfHeigth);
                }
                if(outputPoints.Length == 1)
                {
                    graphics.DrawLine(AI_pen, outputPoints[0],new Point(0, HalfHeigth));
                }
                else
                {
                    graphics.DrawLines(AI_pen, outputPoints);
                }
                

                Pen course_pen = new Pen(Color.Black, 1);
                Point[] coursePoints = new Point[realCourse.Length];
                for (int i = 0; i < coursePoints.Length; i++)
                {
                    coursePoints[i] = new Point((int)((i / (float)l) * width), (int)(-(realCourse[i] - average) * scale) + HalfHeigth);
                }
                if (outputPoints.Length == 1)
                {
                    graphics.DrawLine(course_pen, coursePoints[0], new Point(0, HalfHeigth));
                }
                else
                {
                    graphics.DrawLines(course_pen, coursePoints);
                }



            }

            private float getAverage(float[] data)
            {
                float average = 0;
                foreach(float f in data)
                {
                    average += f;
                }
                average /= data.Length;
                return average;
            }


 


        }

        private class DatasetPositionDisplay
        {
            private PictureBox datasetPosDisplay;
            private int width;
            private int heigth;
            private int HalfHeigth;

            private Graphics graphics;
            private DatasetManager datasetManager;


  
            public DatasetPositionDisplay(PictureBox datasetPosDisplay, DatasetManager manager)
            {
                this.datasetPosDisplay = datasetPosDisplay;
                this.datasetManager = manager;

                manager.dataWalker.datasetChanged += DatasetChanged;
                manager.dataWalker.DatasetPositionChanged += PositionChanged;

                width = datasetPosDisplay.Size.Width;
                heigth = datasetPosDisplay.Size.Height;
                HalfHeigth = heigth / 2;
                graphics = datasetPosDisplay.CreateGraphics();

            }

            private float pictureMoveStep;
            private int currentPicturePosition;


            private DatasetVisualization datasetVisualization;
            public void DatasetChanged()
            {
                if (datasetManager.datasets == null || datasetManager.datasets.Length == 0) return;
                int datasetID = datasetManager.dataWalker.currentDatasetID;
 
                Dataset dataset = datasetManager.datasets[datasetID];

                datasetVisualization = new DatasetVisualization(dataset, width, HalfHeigth);

                pictureMoveStep = (float)dataset.data.Length / width;
                currentPicturePosition = 0;

                DrawDatasetGraphic(datasetVisualization);
                DrawPositionLine(currentPicturePosition);
            }

            public void PositionChanged(int position)
            {
                int newPicturePos = (int)(position / pictureMoveStep);
                if (currentPicturePosition != newPicturePos && datasetVisualization != null)
                {
                    DrawDatasetGraphic(datasetVisualization);
                    DrawPositionLine(newPicturePos);
                    currentPicturePosition = newPicturePos;
                }
            }

            private void DrawDatasetGraphic(DatasetVisualization visualization)
            {
                graphics.Clear(Color.White);
                Pen blackPen = new Pen(Color.Black, 0.5f);
                Point[] graphicPoints = visualization.getGraphicPoints();
                graphics.DrawLines(blackPen, graphicPoints);
            }

            private void DrawPositionLine(int position)
            {
                Pen redPen = new Pen(Color.Red, 1); 
                graphics.DrawLine(redPen, new Point(position,heigth), new Point(position, 0));
            }


            private class DatasetVisualization
            {
                private Point[] pointsToDraw;
                public DatasetVisualization(Dataset dataset, int width, int halfHeigth, float scale = 500)
                {
                    float datasetStep = 1/(dataset.data.Length / (float)width);
                    pointsToDraw = new Point[width];

                    Interval[] data = dataset.data;

                    int H = 0;
                    float avg = 0;
                    float step = 0;
                    int PNum = 0;
                    int fullHeigth = halfHeigth * 2;
                    for (int i = 0; i < data.Length; i++)
                    {
                        avg += data[i].averageCourse * datasetStep;
                        step += datasetStep;
                        if(step >= 1)
                        {
                            step -= 1;
                            avg -= data[i].averageCourse * step;

                            H = (int)(-(avg - dataset.average) * scale) + halfHeigth;
                            H = H < 0 ? 0: H;
                            H = H >= fullHeigth ? fullHeigth : H;

                            pointsToDraw[PNum] = new Point(PNum, H);
                            avg = data[i].averageCourse * step;
                            PNum++;
                        }
                    }
                    if (PNum <= pointsToDraw.Length - 1)
                    {
             
                        avg *= 1 / step;

                        H = (int)(-(avg - dataset.average) * scale) + halfHeigth;
                        H = H < 0 ? 0 : H;
                        H = H >= fullHeigth ? fullHeigth : H;
                        pointsToDraw[PNum] = new Point(PNum, H);
                    }
                }

                public Point[] getGraphicPoints()
                {
                    return pointsToDraw;
                }
            }
        }

        private class AverageAndHighestError
        {
            private TextBox averageErrorValueBox;
            private const int averageinfoCollectionPeriod = 100;
            private LinkedList<float> errors = new LinkedList<float>();

            private TextBox heghestErrTextBox;
            private float maxError;
            public AverageAndHighestError(TextBox averageErrorValueBox, TextBox heghestErrTextBox)
            {
                this.averageErrorValueBox = averageErrorValueBox;
                this.heghestErrTextBox = heghestErrTextBox;

            }

            public void Update(float[] AI_output, float[] realCourse)
            {
                float error = 0;
                for (int i = 0; i < AI_output.Length; i++)
                {
                    error += Math.Abs(realCourse[i] - AI_output[i]);
                }
                //calculating average

                calculateAverage(error);

                //calculating max
                if(error > maxError)
                {
                    maxError = error;
                    WriteTextSafe("Max: " + maxError.ToString(), heghestErrTextBox);
                }
            }

            private void calculateAverage(float error)
            {

                errors.AddLast(error);

                while (errors.Count >= averageinfoCollectionPeriod)
                {
                    errors.RemoveFirst();
                }

                float average = 0;
                foreach (float err in errors)
                {
                    average += err;
                }
                average /= errors.Count;


                WriteTextSafe("Average: " + average.ToString(), averageErrorValueBox);
            }

            public void WriteTextSafe(string text, TextBox textBox)
            {
                if (textBox.InvokeRequired)
                {
                    // Call this same method but append THREAD2 to the text
                    Action safeWrite = delegate { WriteTextSafe(text, textBox); };
                    textBox.Invoke(safeWrite);
                }
                else
                    textBox.Text = text;
            }
        }
    }
}
