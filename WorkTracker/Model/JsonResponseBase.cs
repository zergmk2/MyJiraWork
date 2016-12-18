using RestSharp;

namespace WorkTracker.Model
{
    public abstract class JsonResponseBase
    {
        private ResponseStatus status;
        private string failureReason;


        public ResponseStatus Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public string FailureReason
        {
            get
            {
                return failureReason;
            }

            set
            {
                failureReason = value;
            }
        }
    }

    //public enum ResponseStatus
    //{
    //    OK,
    //    Failed
    //}
}