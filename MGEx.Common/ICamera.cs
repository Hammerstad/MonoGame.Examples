using Microsoft.Xna.Framework;

namespace MGEx.Common
{
    public interface ICamera
    {
        Matrix World { get; }

        Matrix View { get; }

        Matrix Projection { get; }
    }
}
