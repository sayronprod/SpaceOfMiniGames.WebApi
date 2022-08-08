namespace SpaceOfMiniGames.WebApi.Models.ModelsDto
{
    public class BaseResponse
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }

        public void SetSuccess(string message = "")
        {
            IsSuccess = true;
            Message = message;
        }

        public void SetFail(string message = "")
        {
            IsSuccess = false;
            Message = message;
        }
    }
}
