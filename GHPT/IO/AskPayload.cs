using Newtonsoft.Json;

namespace GHPT.IO
{
    public class AskPayload
    {
        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("messages")]
        public List<Message> Messages { get; set; }

        // temperature is only required for GPT-4o and GPT-4.5
        [JsonProperty("temperature")]
        public double? Temperature { get; set; }

        // reasoning_effort is only required for o3-mini and o3-mini-high
        [JsonProperty("reasoning_effort")]
        public string? ReasoningEffort { get; set; }

        public AskPayload()
        {

        }

        public AskPayload(string model, List<Message> messages, double temperature = 0.7)
        {
            this.Model = model;
            this.Messages = messages;
            this.Temperature = temperature;
            this.ReasoningEffort = null;
        }

        public AskPayload(string model, Message msg, double temperature = 0.7)
        {
            this.Model = model;
            this.Messages = new List<Message> { msg };
            this.Temperature = temperature;
            this.ReasoningEffort = null;
        }

        public AskPayload(string model, string msg, double temperature = 0.7)
        {
            this.Model = model;
            this.Messages = new List<Message> { new Message(msg) };
            this.Temperature = temperature;
            this.ReasoningEffort = null;
        }

        // Reinforcement learning methods (o3-mini, o3-mini-high)
        public AskPayload(string model, List<Message> messages, string reasoningEffort = "high")
        {
            this.Model = model;
            this.Messages = messages;
            this.Temperature = 1.0;
            this.ReasoningEffort = reasoningEffort;
        }

        public AskPayload(string model, Message msg, string reasoningEffort = "high")
        {
            this.Model = model;
            this.Messages = new List<Message> { msg };
            this.Temperature = 1.0;
            this.ReasoningEffort = reasoningEffort;
        }

        public AskPayload(string model, string msg, string reasoningEffort = "high")
        {
            this.Model = model;
            this.Messages = new List<Message> { new Message(msg) };
            this.Temperature = 1.0;
            this.ReasoningEffort = reasoningEffort;
        }
    }
}
