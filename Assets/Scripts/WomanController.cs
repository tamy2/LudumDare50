using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomanController : CharController
{
    public TyperNumber typer;
    private bool asking;

    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("gettingUp", false);
        animator.SetBool("sittingDown", true);
        asking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("getUp") && !asking) {
            speechBubble.enabled = true;
            Ask();
            asking = true;
        }
    }

    public void GetUp() {
        animator.SetBool("gettingUp", true);
        animator.SetBool("sittingDown", false);
    }

    public void Ask() {
        typer.SetCurrentNumber();
    }

    public void SitDown() {
        animator.SetBool("sittingDown", true);
        animator.SetBool("gettingUp", false);
    }
}
