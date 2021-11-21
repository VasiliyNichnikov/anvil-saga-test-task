using Enemy;
using Ship;
using Ship.Shooting;
using UnityEngine;

public class VisionGun : MonoBehaviour
{
    [SerializeField] private VisionGunSideRightOrLeft _right;
    [SerializeField] private VisionGunSideRightOrLeft _left;

    public SideGun GetSide()
    {
        if (_right.CanShoot)
            return SideGun.Right;
        return _left.CanShoot ? SideGun.Left : SideGun.None;
    }
}