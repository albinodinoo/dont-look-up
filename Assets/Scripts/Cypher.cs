using UnityEngine;
using System;
using System.IO;

public class Cypher : MonoBehaviour
{
    [SerializeField] private Animator Animate;
    public void SercretRevealed(bool Status){
            Animate.SetBool("Show", Status);
    }
}