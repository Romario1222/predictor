using System;
using System.Collections.Generic;

namespace predictor
{
    public class PredictionManager
    {
        List<string> predictions = new List<string>();

        public void AddPrediction(string prediction)
        {
            predictions.Add(prediction);
        }

        public string GetRandomPrediction()
        {
            if(predictions.Count <= 1)
            {
                return "Нет предсказаний для тебя";
            }
            Random rnd = new Random();
            int predictionNumber = rnd.Next(0, predictions.Count);
            string prediction = predictions[predictionNumber];
            predictions.RemoveAt(predictionNumber);
            return prediction;
        }
    } 
}