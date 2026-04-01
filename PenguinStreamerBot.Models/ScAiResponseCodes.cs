using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PenguinStreamerBot.Models
{
    [Index(nameof(UserId), IsUnique = true)]
    public class ScAiResponseCodes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string UserId { get; set; } = string.Empty;
        public string PreviousResponseId { get; set; } = string.Empty;
    }
}
