namespace MyProject.Areas.Client.StampsDto
{
    public class AddStampRequestDto
    {
        public required string QR { get; set; }

        public required long CouponId { get; set; }
    }
}
