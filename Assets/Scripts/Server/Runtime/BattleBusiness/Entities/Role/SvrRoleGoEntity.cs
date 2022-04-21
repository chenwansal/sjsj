using System;
using UnityEngine;
using JackFrame;

namespace SJSJ.Server.Battle {

    public class SvrRoleGoEntity : MonoBehaviour, IEntity {

        public EntityType EntityType => EntityType.Role;
        int entityID;
        public int EntityID => entityID;

        Transform Body { get; set; }
        Rigidbody Rig { get; set; }

        void Awake() {

            Body = transform.Find("Body");
            Rig = GetComponent<Rigidbody>();

        }

        public void Init() {

        }

        public void Move(Vector2 moveAxis) {

            Vector3 verticalMove = transform.forward * moveAxis.y;
            Vector3 horizontalMove = transform.right * moveAxis.x;

            Vector3 moveDir = verticalMove + horizontalMove;
            moveDir.y = 0;

            var rig = this.Rig;
            float verticalVelocity = rig.velocity.y;
            rig.velocity = moveDir * 5.5f;
            rig.velocity = new Vector3(rig.velocity.x, verticalVelocity, rig.velocity.z);

            LookAt(moveAxis);

        }

        public void LookAt(Vector2 dir) {

            Body.LookAtHorizontal(transform.position + new Vector3(dir.x, 0, dir.y));

        }

    }

}