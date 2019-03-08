using System;
using System.ComponentModel.DataAnnotations;

namespace SafetyBoard.Models
{
    public class Notification
    {
        public int Id { get; private set; }

        public DateTime DateTime { get; private set; }

        public NotificationType Type { get; private set; }

        public DateTime? OriginalDateTime { get; set; }

        public string OriginalVenue { get; set; }

        [Required]
        public Inspection Inspection { get; private set; }

        protected Notification()
        {

        }

        public Notification(Inspection inspection,NotificationType notificationType)
        {
            if (inspection == null)
                throw new ArgumentNullException();

            DateTime = DateTime.Now;
            Inspection = inspection;
            Type = notificationType;
        }
    }
}