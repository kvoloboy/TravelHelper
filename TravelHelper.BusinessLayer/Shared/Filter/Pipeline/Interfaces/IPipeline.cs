namespace BusinessLayer.Shared.Filter.Pipeline.Interfaces
{
    public interface IPipeline <out TOutput>
    {
        TOutput Execute();
    }
}
