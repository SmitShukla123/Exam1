namespace Exam1.Model
{

    public enum Response_Status
    {
        Success=200,
        Fail=400
    }
    public class Response<T>
    {
        public T? Data { get; set; }
        public string? Success_Message {  get; set; }
        public string? Error_Message { get; set; }

        public string? Display_Error_Message {  get; set; }

        public bool IsSuccess {  get; set; }
        public Response_Status Status { get; set; }

        public string Token { get; set; }

        public int PageNumber { get; set; } // Current Page Number
        public int PageSize { get; set; }   // Number of Records Per Page
        public int TotalRecords { get; set; }
    }
}
