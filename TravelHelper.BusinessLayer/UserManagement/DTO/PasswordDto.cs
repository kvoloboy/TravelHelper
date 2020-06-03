namespace BusinessLayer.UserManagement.DTO
{
    public class PasswordDto
    {
        public PasswordDto(string value)
        {
            Value = value;
        }
        public string Value { get; }
    }
}
