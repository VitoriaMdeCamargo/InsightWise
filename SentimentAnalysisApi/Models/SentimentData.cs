using Microsoft.ML.Data;

namespace SentimentAnalysisApi.Models
{
    public class SentimentData
    {
        public string Text { get; set; }
        public bool Label { get; set; }
    }

    public class SentimentPrediction
    {
        [ColumnName("PredictedLabel")]
        public bool Prediction { get; set; }
        public float[] Score { get; set; }
    }
}

