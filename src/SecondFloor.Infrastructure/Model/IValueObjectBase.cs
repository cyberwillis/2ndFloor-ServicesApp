﻿namespace SecondFloor.Infrastructure.Model
{
    public interface IValueObjectBase
    {
        //IDictionary<string,string> BrokenRules { get; }
        void AddBrokenRule(string key, string message);
        void ClearBrokenRules();
    }
}