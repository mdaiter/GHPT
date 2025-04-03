namespace GHPT.Configs
{
    public static class Models
    {
        public static Dictionary<string, GPTVersion> ModelOptions = new()
        {
            { "o3-mini", GPTVersion.GPTO3_MINI },
            { "o3-mini-high", GPTVersion.GPTO3_MINI_HIGH },
            { "gpt-4o", GPTVersion.GPT4_O },
            { "gpt-4.5", GPTVersion.GPT4_5 },
            { "gpt-4", GPTVersion.GPT4 },
            { "gpt-3.5-turbo", GPTVersion.GPT3_5 },
            { "gpt-3.5-turbo-0301", GPTVersion.GPT3_5 },
            { "gpt-3.5-turbo-0613", GPTVersion.GPT3_5 },
            { "gpt-3.5-turbo-16k", GPTVersion.GPT3_5 },
            { "gpt-3.5-turbo-16k-0613", GPTVersion.GPT3_5 },
        };
    }
}
