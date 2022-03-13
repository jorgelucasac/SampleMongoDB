﻿using Estudos.MongoDb.Api.Profiles;

namespace Estudos.MongoDb.Api.Extensions;

public static class AutoMapperExtension
{
    public static void AddAutoMapperExtension(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(RestaurantProfile));
    }
}