using System.ComponentModel.DataAnnotations;

namespace XtraWork.Responses;

public class TitleResponse
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
}