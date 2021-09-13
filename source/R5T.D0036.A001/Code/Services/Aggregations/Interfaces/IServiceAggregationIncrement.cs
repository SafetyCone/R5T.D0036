using System;

using R5T.Dacia;


namespace R5T.D0036.A001
{
    public interface IServiceAggregationIncrement
    {
        IServiceAction<ISourceControlOperator> SourceControlOperatorAction { get; set; }
    }
}
