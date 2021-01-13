using System;
using System.Collections.Generic;

namespace predictor
{
    public class PredictionManager
    {
        List<string> predictions = new List<string>();

        public PredictionManager()
        {
            predictions.Add("Думаю, что тебя ждут решительные меры...");
            predictions.Add("Возможно стоит подумать об осадках");
            predictions.Add("Если и гнать самогон, то лучше не на этой неделе");
            predictions.Add("Обсуждения родственников с другими родственниками... Очень вероятный сценарий");
            predictions.Add("Похоже ты погрязнешь в рутине");
            predictions.Add("Если и мечтать то о лете. Возможно на этой неделе есть смысл?");
        }

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
            return prediction;
        }

        public List<string> GetCurrentPredictions(){
            return predictions;
        }

        public void SavePredictions(string[] predictiosArray)
        {
            predictions.Clear();
            foreach(var prediction in predictiosArray){
                predictions.Add(prediction);
            }
        }
    } 
}