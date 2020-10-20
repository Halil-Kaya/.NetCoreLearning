namespace UdemyApiWithToken.Domain.Responses
{
    public class BaseResponse<T> where T:class
    {
        public T Extra { get; set; }
        public bool Success { get; set; }

        public string Message { get; set; }

        public BaseResponse(T extra)
        {
            this.Success = true;
            this.Extra = extra;
        }

        public BaseResponse(string message)
        {
            this.Success = false;
            this.Message = message;
        }

        

    }
}