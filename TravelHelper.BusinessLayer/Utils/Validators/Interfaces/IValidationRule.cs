namespace BusinessLayer.Utils.Validators.Interfaces
{
    public interface IValidationRule<TInput>
    {
        Result Check(TInput input);
    }
}
