﻿using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Replicate.Net.Common.Example.Client;
using RestEase;

namespace Replicate.Net.Common.Example.Factory;

public class ExampleApiFactory : IExampleApiFactory
{
	public static readonly Uri PredictionBaseUrl = new(Environment.GetEnvironmentVariable("ExamplePredictionBaseUrl")!);

	public static readonly JsonSerializerSettings Settings = new()
	{
		ContractResolver = new DefaultContractResolver
		{
			NamingStrategy = new SnakeCaseNamingStrategy()
		},
		Formatting = Formatting.Indented,
		NullValueHandling = NullValueHandling.Ignore
	};

	public IExampleApi GetApi()
	{
		return new RestClient(PredictionBaseUrl)
		{
			JsonSerializerSettings = Settings
		}
		.For<IExampleApi>();
	}
}