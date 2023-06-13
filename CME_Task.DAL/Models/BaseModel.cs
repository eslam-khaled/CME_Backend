using System;
using System.Collections.Generic;
using System.Text;

namespace CME_Task.DAL.Models;

public class BaseModel
{
    public int ID { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt = DateTime.Now;
    public string? CreatedBy { get; set; }
}
