using Coursework.Application.NearbySearch.Abstract;
using Coursework.Application.NearbySearch.Models;
using Coursework.Infrastructure.MaptilerSearch.Abstract;
using Coursework.Infrastructure.MaptilerSearch.Models;
using Coursework.Infrastructure.Extensions;

namespace Coursework.Application.NearbySearch.Services
{
    public class NearbySearchService : INearbySearchService
    {
        private readonly IMaptilerService _maptilerService;

        /// <summary>
        /// kilometerCoefficient - the coefficient to convert miles to kilometers.
        /// The Haversin function returns the distance between two points in kilometers,
        /// so need to convert miles to kilometers to compare distances.
        /// </summary>
        const double kilometerCoefficient = 1.609;

        /// <summary>
        /// radius - Earth radius in kilometers.
        /// </summary>
        const int radius = 6371;

        public NearbySearchService(IMaptilerService maptilerService)
        {
            _maptilerService = maptilerService;
        }

        public async Task<bool> CheckCityInRadius(LocationRequestModel locationRequestModel, CancellationToken cancellationToken)
        {
            var referenceLocation = new Location() { };

            var referenceAddressDataResponse = await _maptilerService.
                GetDataByAddress(locationRequestModel.ReferenceAddress.ReplaceSpaceAndComma(), cancellationToken);

            if (referenceAddressDataResponse.Features.Count == 0)
            {
                throw new Exception($"Address {locationRequestModel.ReferenceAddress} not found");
            }

            var coordinates = referenceAddressDataResponse.Features.FirstOrDefault().Center;

            referenceLocation.Latitude = coordinates[1].ToString();
            referenceLocation.Longitude = coordinates[0].ToString();

            var distanceBetweenLocations = HaversineCalculate(referenceLocation, locationRequestModel.MainLocation);

            if (distanceBetweenLocations >= locationRequestModel.MaxDistance * kilometerCoefficient)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// this method implemented uses the ‘haversine’ formula
        /// to calculate the great-circle distance between two points –
        /// that is, the shortest distance over the earth’s surface – giving an ‘as-the-crow-flies’
        /// distance between the points
        /// </summary>
        /// <param name="referenceLocation"></param>
        /// <param name="mainLocation"></param>
        /// <returns></returns>
        private double HaversineCalculate(Location referenceLocation, Location mainLocation)
        {
            double.TryParse(referenceLocation.Latitude, out double referenceLatitude);
            double.TryParse(referenceLocation.Longitude, out double referenceLongitude);

            double.TryParse(mainLocation.Latitude, out double mainLatitude);
            double.TryParse(mainLocation.Longitude, out double mainLongitude);

            var dLat = DoubleToRadians(mainLatitude - referenceLatitude);
            var dLon = DoubleToRadians(mainLongitude - referenceLongitude);
            referenceLatitude = DoubleToRadians(referenceLatitude);
            mainLatitude = DoubleToRadians(mainLatitude);

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(referenceLatitude) * Math.Cos(mainLatitude);
            var c = 2 * Math.Asin(Math.Sqrt(a));
            return radius * c;
        }

        private double DoubleToRadians(double angle)
            => Math.PI * angle / 180.0;
    }
}
