﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireballTurret : Ability
{
    public FireballTurret(AttackType attackType, DamageType damageType, float range, float angle, float cooldown, float damageMod, float resourceCost, string id, string readable, GameObject particles)
        : base(attackType, damageType, range, angle, cooldown, damageMod, resourceCost, id, readable, particles)
    {

    }

    public override void SpawnProjectile(GameObject source, GameObject owner, Vector3 forward, string abilityID, bool isPlayer)
    {
        int segments = 1;
        GameObject projectile = (GameObject)GameObject.Instantiate(particleSystem, source.transform.position + forward, source.transform.rotation);


        projectile.GetComponent<ProjectileBehaviour>().owner = owner;
        projectile.GetComponent<ProjectileBehaviour>().timeToActivate = 12.0f;
        projectile.GetComponent<ProjectileBehaviour>().abilityID = abilityID;
        projectile.GetComponent<ProjectileBehaviour>().ExplodesOnTimeout = false;
        projectile.GetComponent<ProjectileBehaviour>().hasCollided = true;
        

        //projectile.rigidbody.velocity = Vector3.zero;


        int tempindex = 10;
        while (owner.GetComponent<Entity>().abilityManager.abilities[tempindex] != null && owner.GetComponent<Entity>().abilityManager.abilities[tempindex].ID != "fireball")
        {
            tempindex++;
        }
        if (owner.GetComponent<Entity>().abilityManager.abilities[tempindex] == null)
        {
            owner.GetComponent<Entity>().abilityManager.AddAbility(GameManager.Abilities["fireball"], tempindex);
            owner.GetComponent<Entity>().abilityIndexDict["fireball"] = tempindex;
            Debug.Log("fireball added to " + tempindex);
        }
        /*
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out rayCastTarget, Mathf.Infinity);
        vectorToMouse = rayCastTarget.point - SourceEntity.transform.position;
        forward = new Vector3(vectorToMouse.x, SourceEntity.transform.forward.y, vectorToMouse.z).normalized;
        */

    
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().RunCoroutine(launch(projectile, owner, tempindex, isPlayer));
    }

    public IEnumerator launch(GameObject source, GameObject owner, int tempindex, bool isplayer)
    {
        for (int i = 0; i < 12; i++)
        {
            List<GameObject> target;
            target = OnAttack(source, isplayer);
            Debug.Log("attacking");

            foreach (GameObject enemy in target)
            {
                Vector3 forward = (enemy.transform.position - source.transform.position).normalized;
                
                owner.GetComponent<Entity>().abilityManager.abilities[tempindex].SpawnProjectile(source, owner, forward, owner.GetComponent<Entity>().abilityManager.abilities[tempindex].ID, isplayer);
                  
            }



            //Vector3 forward = new Vector3(Random.Range(-1.0f, 1.0f), owner.GetComponent<Entity>().transform.forward.y, Random.Range(-1.0f, 1.0f)).normalized;
            //owner.GetComponent<Entity>().abilityManager.abilities[tempindex].SpawnProjectile(source, owner, forward, owner.GetComponent<Entity>().abilityManager.abilities[tempindex].ID, isplayer);
            //SpawnProjectile(SourceEntity.gameObject, rayCastTarget.point, SourceEntity.gameObject, forward, SourceEntity.abilityManager.abilities[tempindex].ID, true);
            yield return new WaitForSeconds(1.0f);
        }


        yield return null;
    }
}
