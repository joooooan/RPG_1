///////////////////////////////////////////////////////////////////////////
//  Melee Warrior Left Hand IK - MonoBehaviour Script				     //
//  Kevin Iglesias - https://www.keviniglesias.com/     			     //
//  Contact Support: support@keviniglesias.com                           //
///////////////////////////////////////////////////////////////////////////

// This script will enable IK of the left hand when needed in the animation
// used on your custom 3D model to make animations that holds weapons with
// both hands look good. It requires the 'Retargeters' empty gameobjects 
// and a child called 'LeftHandIK'. 
// More information at Documentation PDF file.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KevinIglesias {
	public class MeleeWarriorLeftHandIK : MonoBehaviour
	{
		public Transform retargeter;
        public GameObject leftHandEffector;

		private Animator animator;

		private float weight;

		void Start()
        {
			//Debug.Log(leftHandEffector.name);
        }

		void Update()
		{
			weight = retargeter.localPosition.y;
			animator = GetComponent<Animator>();
			weight = 0f;
		}
		
		void OnAnimatorIK(int layerIndex)
		{
			animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, weight);

            if(leftHandEffector != null) animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandEffector.transform.position);
        }

        public bool isEquip()
        {
            if (leftHandEffector.gameObject.name == "Hand") return false;
            else return true;
        }

		public GameObject GetGameObject()
        {
			return leftHandEffector.transform.GetChild(0).gameObject;

		}

	}
}
