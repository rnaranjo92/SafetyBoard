using System;

namespace SafetyBoard.Models
{
    public class Notification
    {
        public int Id { get; private set; }

        public DateTime DateTime { get; private set; }

        public NotificationType Type { get; private set; }

        public Inspection Inspection { get; private set; }

        public SafetyNews SafetyNews { get; private set; }

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
        private Notification(SafetyNews safetyNews, NotificationType notificationType)
        {
            if(safetyNews == null)
                throw new ArgumentNullException();

            DateTime = DateTime.Now;
            SafetyNews = safetyNews;
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
        public static Notification NewSafetyNews(SafetyNews safetyNews)
        {
            return new Notification(safetyNews, NotificationType.SafetyNewsPosted);
        }
        
    }
}