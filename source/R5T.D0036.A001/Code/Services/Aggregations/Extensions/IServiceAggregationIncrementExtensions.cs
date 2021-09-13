using System;

using R5T.D0036.A001;


namespace System
{
    public static class IServiceAggregationIncrementExtensions
    {
        public static T FillFrom<T>(this T aggregation,
            IServiceAggregationIncrement other)
            where T : IServiceAggregationIncrement
        {
            aggregation.SourceControlOperatorAction = other.SourceControlOperatorAction;

            return aggregation;
        }
    }
}
