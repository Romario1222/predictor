using System;
using System.Collections.Generic;

namespace predictor
{
    public class PredictionManager
    {
        List<string> predictions = new List<string>();
        Random rnd = new Random();

        public PredictionManager()
        {
            predictions.Add("Думаю, что тебя ждут решительные меры...");
            predictions.Add("Возможно стоит подумать об осадках. Они застают врасплох в поездках на природу.");
            predictions.Add("Обсуждения родственников с другими родственниками... Очень вероятный сценарий");
            predictions.Add("Тебя точно ждёт крутой день. Главное не обновляй эту страничку!");
            predictions.Add("Похоже ты погрязнешь в рутине. Но возможно есть смысл спросить о другом предсказании");
            predictions.Add("Если и мечтать, то о лете. Возможно на этой неделе есть смысл?");
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