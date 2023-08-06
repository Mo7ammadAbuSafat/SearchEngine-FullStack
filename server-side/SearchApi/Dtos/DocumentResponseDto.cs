namespace SearchApi.Dtos
{
    public class DocumentResponseDto
    {
        public int Score { get; set; }
        public string Text { get; set; } = string.Empty;
    }
}
