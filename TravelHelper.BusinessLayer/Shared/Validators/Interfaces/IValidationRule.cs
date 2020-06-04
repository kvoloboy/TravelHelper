namespace BusinessLayer.Shared.Validators.Interfaces
{
    public interface IValidationRule<TInput>
    {
        Result Check(TInput input);
    }
}
