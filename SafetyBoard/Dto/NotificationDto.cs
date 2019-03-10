using SafetyBoard.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace SafetyBoard.Dto
{
    public class NotificationDto
    {
        public DateTime DateTime { get; private set; }

        public NotificationType Type { get; private set; }

        [Required]
        public InspectionDto Inspection { get; private set; }

    }
}