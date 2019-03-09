using System;
using System.ComponentModel.DataAnnotations;

namespace SafetyBoard.Models
{
    public class Notification
    {
        public int Id { get; private set; }

        public DateTime DateTime { get; private set; }

        public NotificationType Type { get; private set; }

        [Required]
        public Inspection Inspection { get; private set; }

        protected Notification()
        {

        }

        private Notification(Inspection inspection,NotificationType notificationType)
        {
            if (inspection == null)
                throw new ArgumentNullException();

            DateTime = DateTime.Now;
            Inspection = inspection;
            Type = notificationType;
        }
        public static Notification InspectionCreated(Inspection inspection)
        {
            return new Notification(inspection,NotificationType.InspectionCreated);
        }
        public static Notification InspectionUpdated(Inspection inspection)
        {
            return new Notification(inspection, NotificationType.InspectionUpdated);
        }
        public static Notification InspectionCanceled(Inspection inspection)
        {
            return new Notification(inspection, NotificationType.InspectionCanceled);
        }
    }
}