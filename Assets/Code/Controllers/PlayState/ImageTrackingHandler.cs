using System;
using TestAssingment.Interfaces;
using TestAssingment.View;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace TestAssingment.Controllers
{
    public sealed class ImageTrackingHandler: ICleanup, IDisposable
    {
        private readonly ARTrackedImageManager _arTrackedImageManager;
        private bool _objectsSpawned;
        
        public event Action<string, Transform> OnImageCaught;
        public event Action<string, Transform> OnPositionTracked;
        public ImageTrackingHandler(ReferenceHolder referenceHolder)
        {
            _arTrackedImageManager = referenceHolder.ARTrackedImageManager;
            var arSession = referenceHolder.ArSession;
            arSession.Reset();
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
            foreach (var trackedImage in trackingImages.updated)
            {
                if (!_objectsSpawned)
                {
                    if (trackedImage.trackingState == TrackingState.Tracking)
                    {
                        var imageName = trackedImage.referenceImage.name;
                        var imageTransform = trackedImage.transform;
                        OnImageCaught?.Invoke(imageName, imageTransform);
                    }
                }
                else
                {
                    if (trackedImage.trackingState == TrackingState.Tracking)
                    {
                        var imageName = trackedImage.referenceImage.name;
                        var imageTransform = trackedImage.transform;
                        OnPositionTracked?.Invoke(imageName, imageTransform);
                    }
                }
            }
        }

        public void IsObjectSpawned(bool value)
        {
            _objectsSpawned = value;
        }
    }
}