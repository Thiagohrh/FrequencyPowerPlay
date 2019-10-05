using UnityEngine;

public class FrequencyConverter
{
    private float[] frequencyBand = new float[8];
    public float[] ConvertToBands(float[] newSamples)
    {
        /*
         * 22050 / 512 = 43hertz per sample
         * 
         * 20 - 60 hertz
         * 60 - 250 hertz
         * 250 - 500 hertz
         * 500 - 2000 hertz
         * 2000 - 4000 hertz
         * 4000 - 6000 hertz
         * 6000 - 20000 hertz
         * 
         * 0 - 2 = 86 hertz
         * 1 - 4 = 172 hertz - 87 - 258
         * 2 - 8 = 344 hertz - 259 - 682
         * 3 - 16 = 688 hertz - 603 - 1290
         * 4 - 32 = 1376 hertz - 1291 - 2666
         * 5 - 64 = 2752 hertz - 5667 - 5418
         * 6 - 128 = 5504 hertz - 5419 - 10922
         * 7 - 256 = 11088 hertz - 10923 - 21930
         * 510
         */

        int count = 0;
        for (int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;

            if (i == 7)
            {
                sampleCount += 2;
            }

            for (int j = 0; j < sampleCount; j++)
            {
                average += newSamples[count] * (count + 1);
                count++;
            }

            average /= count;

            this.frequencyBand[i] = average * 10;
        }

        return this.frequencyBand;
    }
}
