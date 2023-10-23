using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XtraWork.Entities;

public class Title
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
}