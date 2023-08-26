using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using CryptoAnalizerAI.AI_training.CustomDatasets;

namespace CryptoAnalizerAI.AI_training
{
    public class TrainingVisualizer
    {
        private CurrentErrorDisplay currentError;
        private DatasetPositionDisplay positionDisp;
        private AverageValuesDisp averageAndHighestErrDisp;
        private TrainDataWalkingStatistic trainWalkerStat;
        public TrainingVisualizer(PictureBox CurrentErrorDisplayPicture,TextBox averageErrorValueBox, TextBox highestErrTextBox, PictureBox learnPosGraphic, manual_AI_Trainer trainer,
            TextBox datasetNumDisp, TextBox dataNumDisp, DatasetManager manager, TrainingWindow window,TextBox averageAIOutputValueBox, TextBox averageRealCourseChangeValueBox)
        {
            currentError = new CurrentErrorDisplay(CurrentErrorDisplayPicture);
            averageAndHighestErrDisp = new AverageValuesDisp(averageErrorValueBox, averageAIOutputValueBox, averageRealCourseChangeValueBox, highestErrTextBox);
            trainer.predictionEvent_retDif += currentError.Update;
            trainer.predictionEvent_retDif += averageAndHighestErrDisp.Update;
            positionDisp = new DatasetPositionDisplay(learnPosGraphic,  trainer.datasetManager);
            trainWalkerStat = new TrainDataWalkingStatistic(manager, datasetNumDisp, dataNumDisp, window, trainer);
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

                graphics.Clear(Color.White);

                Pen AI_pen = new Pen(Color.Green,1);
                Point[] outputPoints = new Point[AI_output.Length];
                for (int i = 0; i < outputPoints.Length; i++)
                {
                    outputPoints[i] = new Point( (int)((i/(float)(l-1)) * width), (int)(-AI_output[i] * scale) + HalfHeigth);
                    if (outputPoints[i].Y > heigth)
                    {
                        outputPoints[i].Y = heigth;
                    }
                    if(outputPoints[i].Y < 0)
                    {
                        outputPoints[i].Y = 0;
                    }
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
                    coursePoints[i] = new Point((int)((i / (float)(l - 1)) * width), (int)(-realCourse[i] * scale) + HalfHeigth);
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

        private class AverageValuesDisp
        {

            private TextBox heghestErrTextBox;
            private float maxError;

            private AverageValueDisp averageErrorDisp;

            private AverageValueDisp averageAIOutputDisp;
            private AverageValueDisp averageRealCourseChangeDisp;
            public AverageValuesDisp(TextBox averageErrorValueBox, TextBox averageAiOutput, TextBox averageRealCourseChange, TextBox heghestErrTextBox)
            {
                averageErrorDisp = new AverageValueDisp(averageErrorValueBox, "Avg err");
                averageAIOutputDisp = new AverageValueDisp(averageAiOutput, "Avg AI_o");
                averageRealCourseChangeDisp = new AverageValueDisp(averageRealCourseChange, "Avg rC");
                this.heghestErrTextBox = heghestErrTextBox;

            }

            public void Update(float[] AI_output, float[] realCourse)
            {
                float error = 0;
                float ai_output = 0;
                float courseChange = 0;
                for (int i = 0; i < AI_output.Length; i++)
                {
                    error += Math.Abs(realCourse[i] - AI_output[i]);
                    ai_output += AI_output[i];
                    courseChange += realCourse[i];
                }
                //calculating average
                averageErrorDisp.Update(error);
                averageAIOutputDisp.Update(ai_output);
                averageRealCourseChangeDisp.Update(courseChange);

                //calculating max
                if (error > maxError)
                {
                    maxError = error;
                    WriteTextSafe("Max err: " + maxError.ToString(), heghestErrTextBox);
                }
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



            private class AverageValueDisp
            {
                private LinkedList<float> values = new LinkedList<float>();
                private string desc;
                public AverageValueDisp(TextBox disp,string description, int infoCollectPeriod = 100)
                {
                    this.disp = disp;
                    desc = description;
                    averageCollectingPeriod = infoCollectPeriod;
                }

                private TextBox disp;
                private int averageCollectingPeriod;
                public void Update(float newValue)
                {

                    values.AddLast(newValue);

                    while (values.Count >= averageCollectingPeriod)
                    {
                        values.RemoveFirst();
                    }

                    float average = 0;
                    foreach (float err in values)
                    {
                        average += err;
                    }
                    average /= values.Count;

                    string text = average.ToString("N5");
                    if (float.IsNaN(average)) text = "zero";
                    if (float.IsPositiveInfinity(average)) text = "+infinity";
                    if (float.IsNegativeInfinity(average)) text = "-infinity";
                    WriteTextSafe(desc + ": " + text, disp);
                }

                private void WriteTextSafe(string text, TextBox textBox)
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

        private class TrainDataWalkingStatistic
        {
            private manual_AI_Trainer trainer;

            private TextBox datasetCounterDisp;
            private TextBox stepCounterDisp;

            private TrainingWindow window;
            public TrainDataWalkingStatistic(DatasetManager manager, TextBox datasetCounterDisp, TextBox stepCounterDisp, TrainingWindow window, manual_AI_Trainer trainer)
            {
                this.datasetCounterDisp = datasetCounterDisp;
                this.stepCounterDisp = stepCounterDisp;
                this.window = window;
                this.trainer = trainer;

                trainer.onRunEnd += newRun;
                trainer.onTrainingStart += newRun;
                manager.dataWalker.DatasetPositionChanged += dataWalked;
            }

            private void newRun()
            {
                if (!window.InvokeRequired) return;
                int runNum = trainer.runNum;
                window.BeginInvoke(new textSet(setText), datasetCounterDisp, runNum.ToString());
            }

            private void dataWalked(int num)
            {
                if (!window.InvokeRequired) return;
                window.BeginInvoke(new textSet(setText), stepCounterDisp, num.ToString());

            }

            private void setText(TextBox box,string text)
            {
                box.Text = text;
            }

            private delegate void textSet(TextBox box, string text);
        }
    }
}
