using System;
using TestAssingment.Interfaces;
using TestAssingment.View;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace TestAssingment.Controllers
{
    public sealed class ImageTrackingHandler: ICleanup, IDisposable
    {
        private readonly ARTrackedImageManager _arTrackedImageManager;
        public event Action<string, Transform> OnImageCaught;
        
        public ImageTrackingHandler(ReferenceHolder referenceHolder)
        {
            _arTrackedImageManager = referenceHolder.ARTrackedImageManager;
            _arTrackedImageManager.trackedImagesChanged += ImageCaught;
        }

        public void Cleanup()
        {
            _arTrackedImageManager.trackedImagesChanged -= ImageCaught;
        }

        public void Dispose()
        {
            _arTrackedImageManager.trackedImagesChanged -= ImageCaught;
        }

        private void ImageCaught(ARTrackedImagesChangedEventArgs trackingImages)
        {
            
            foreach (var trackedImage in trackingImages.added)
            {
                var imageName = trackedImage.referenceImage.name;
                var imageTransform = trackedImage.transform;

                OnImageCaught?.Invoke(imageName, imageTransform);
            }
        }
    }
}