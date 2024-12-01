using API.Helpers;
using API.Interfaces;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Options;

namespace API.Services;

public class PhotoService : IPhotoService
{
	private readonly Cloudinary _cloudinary;

	public PhotoService(IOptions<ClodinarySettings> config)
	{
		var acc = new Account(config.Value.CloudName,
		config.Value.ApiKey,
		config.Value.ApiSecret);

		_cloudinary = new Cloudinary(acc);
	}

	public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
	{
		if (file.Length == 0) throw new Exception("File is empty");

		using var stream = file.OpenReadStream();
		var uploadParams = new ImageUploadParams
		{
			File = new FileDescription(file.FileName, stream),
			Transformation = new Transformation()
			.Height(500)
			.Width(500)
			.Crop("fill")
			.Gravity("face"),
			Folder = "datingapp",
		};

		var uploadResult = await _cloudinary.UploadAsync(uploadParams);

		return uploadResult;
	}

	public async Task<DeletionResult> DeletePhotoAsync(string publicId)
	{
		var deleteParams = new DeletionParams(publicId);

		return await _cloudinary.DestroyAsync(deleteParams);
	}
}
