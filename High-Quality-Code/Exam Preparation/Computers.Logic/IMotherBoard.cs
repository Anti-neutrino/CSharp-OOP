namespace Computers.Logic
{
    public interface IMotherBoard 
    { 
        /// <summary>
        /// Load value from the RAM
        /// </summary>
        /// <returns>The loaded value</returns>
        int LoadRamValue();
        
        /// <summary>
        /// Save value from RAM
        /// </summary>
        /// <param name="value">The value to save.</param>
        void SaveRamValue(int value);

        /// <summary>
        /// Draw on video card.
        /// </summary>
        /// <param name="data">The text ti draw.</param>
        void DrawOnVideoCard(string data);
    }
}