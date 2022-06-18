namespace Battle
{
    public class WalkCounter
    {
        private float walkCount;
        private float destination;

        public WalkCounter(float destination)
        {
            this.destination = destination;
            walkCount = 0f;
        }

        public void Walk(float distance)
        {
            walkCount += distance;
        }

        public bool IsReachedDestination()
        {
            return walkCount >= destination;
        }

        public float GetCount()
        {
            return walkCount;
        }

        public float GetRemainingMeters()
        {
            return destination - walkCount;
        }

        public float GetRemainingMetersPer()
        {
            return walkCount / destination;
        }
    }
}
