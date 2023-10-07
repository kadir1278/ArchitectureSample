using EntityLayer.ViewModel.Tile;

namespace BusinessLayer.Methots
{
    public static class TileMethots
    {
        public static TileSquareMetersCalculationViewModel SquareMeters(decimal tileWidth,
                                                                 decimal tileLength,
                                                                 decimal tileSquareMeter,
                                                                 decimal totalSquare,
                                                                 int cuttingRate)
        {
            decimal requiredSquareMeters = totalSquare + (totalSquare * cuttingRate / 100);
            decimal requiredTileCount = Math.Round(requiredSquareMeters / (tileWidth * tileLength));
            decimal totalPrice = requiredTileCount * tileSquareMeter;

            return new TileSquareMetersCalculationViewModel()
            {
                RequiredSquareMeters = requiredSquareMeters,
                RequiredTileCount = requiredTileCount,
                TotalPrice = totalPrice
            };
        }
    }
}
