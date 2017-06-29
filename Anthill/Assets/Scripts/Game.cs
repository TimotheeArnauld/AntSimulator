using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AntClass;
using UnityEngine.UI;
using System;
using AntSimulator;
using AntSimulator.Personnage;
using AntSimulator.Objet;

public class Game : MonoBehaviour {
	public GameObject antGameObject;
	public GameObject nutritiveValue;
	public GameObject riceObject;
	public GameObject rainParticleSystem;
	private enum direction{UP, DOWN, LEFT, RIGHT};
	private List<GameObject> ant = new List<GameObject>();
	private List<GameObject> rice = new List<GameObject>();
	public List<GameObject> toRemoveAnt = new List<GameObject> ();
	public List<GameObject> toRemoveRice = new List<GameObject> ();
	public Text timer;
	float startFrom = 0.0f;
	private bool play = true;
	private GestionnaireDeTour g = new GestionnaireDeTour();

	void Start () {
		g.init();

		/*g.ajouterFourmi(((int)FourmiliereConstante.typeFourmie.fourmiReine));
		g.ajouterFourmi((int)FourmiliereConstante.typeFourmie.fourmiOuvriere);
		g.ajouterFourmi((int)FourmiliereConstante.typeFourmie.fourmiGuerriere);
		g.ajouterFourmi((int)FourmiliereConstante.typeFourmie.fourmiChaman);
		g.ajouterFourmi(((int)FourmiliereConstante.typeFourmie.oeufFourmiGuerriere));
		g.ajouterFourmi(((int)FourmiliereConstante.typeFourmie.oeufFourmiOuvriere));
		g.ajouterFourmi(((int)FourmiliereConstante.typeFourmie.oeufFourmiChaman));

		g.sauvegarde ();*/
		g.charger();

		foreach (Fourmi f in g.environnementFourmiliere.PersonnagesList) {
			Ant antproperties = new Ant ();
			antproperties.name = f.GetType().ToString().Substring(f.GetType().ToString().LastIndexOf(".Fourmi") + 7) + " " + f.id;
			antproperties.name = f.GetType().ToString().Substring(f.GetType().ToString().LastIndexOf(".") + 1) + " " + f.id;
			antproperties.id = f.id;
			print (f.GetType());
			GameObject tmp = Instantiate(antGameObject);
			tmp.transform.position = new Vector3 (0, 0, 0);
			tmp.GetComponent<AntController> ().properties = antproperties;
			ant.Add (tmp);
		}

		addFood ();	
		StartCoroutine (EventsHandler());
	}

	void Update () {
		if (play) {
			startFrom += Time.deltaTime;
			TimeSpan t = TimeSpan.FromSeconds (startFrom);
			timer.text = string.Format ("{0:00}:{1:00}",  
				t.Minutes, 
				t.Seconds);
		}
	}

	void addFood(){
		g.ajouterObjet(((int)FourmiliereConstante.typeObjectAbstrait.nourriture),9, 9);
		Nourriture n = (Nourriture)(g.environnementFourmiliere.ObjetsList[g.environnementFourmiliere.ObjetsList.Count - 1]);
		GameObject tmp = Instantiate(riceObject);
		tmp.transform.position = new Vector3 (-1f, -1f, 0);
		tmp.GetComponent<RiceController> ().riceId = n.id;
		rice.Add (tmp);
		g.ajouterObjet(((int)FourmiliereConstante.typeObjectAbstrait.nourriture),19, 19);
		n = (Nourriture)(g.environnementFourmiliere.ObjetsList[g.environnementFourmiliere.ObjetsList.Count - 1]);
		tmp = Instantiate(riceObject);
		tmp.transform.position = new Vector3 (9f, 9f, 0);
		tmp.GetComponent<RiceController> ().riceId = n.id;
		rice.Add (tmp);
		g.ajouterObjet(((int)FourmiliereConstante.typeObjectAbstrait.nourriture),8, 8);
		n = (Nourriture)(g.environnementFourmiliere.ObjetsList[g.environnementFourmiliere.ObjetsList.Count - 1]);
		tmp = Instantiate(riceObject);
		tmp.transform.position = new Vector3 (-2f, -2f, 0);
		tmp.GetComponent<RiceController> ().riceId = n.id;
		rice.Add (tmp);
		g.ajouterObjet(((int)FourmiliereConstante.typeObjectAbstrait.nourriture),8, 12);
		n = (Nourriture)(g.environnementFourmiliere.ObjetsList[g.environnementFourmiliere.ObjetsList.Count - 1]);
		tmp = Instantiate(riceObject);
		tmp.transform.position = new Vector3 (-2f, 2f, 0);
		tmp.GetComponent<RiceController> ().riceId = n.id;
		rice.Add (tmp);
	}

	private IEnumerator EventsHandler(){
		for (int i = 0; i < 80; i++){
			yield return new WaitForSeconds (1.0f);
			nutritiveValue.GetComponent<Text> ().text = (g.environnementFourmiliere.fourmiliere.valeurNutritiveTotalFourmiliere).ToString();
			if (g.pluie == true) {
				rainParticleSystem.GetComponent<ParticleSystem> ().Play ();
			} else {
				rainParticleSystem.GetComponent<ParticleSystem> ().Pause ();
			}
			g.executerTour ();
			foreach (PersonnageAbstrait p in g.environnementFourmiliere.PersonnagesList) {
				Boolean find = false;
				int cpt = 0;
				while (!find && cpt < ant.Count) {
					if (p.id == ant [cpt].GetComponent<AntController> ().properties.id)
						find = true;
					cpt++;
				}
				if (!find) {
					Ant antproperties = new Ant ();
					antproperties.name = p.GetType().ToString().Substring(p.GetType().ToString().LastIndexOf(".Fourmi") + 7) + " " + p.id;
					antproperties.name = p.GetType().ToString().Substring(p.GetType().ToString().LastIndexOf(".") + 1) + " " + p.id;
					antproperties.id = p.id;
					GameObject tmp = Instantiate(antGameObject);
					tmp.transform.position = new Vector3 (0, 0, 0);
					tmp.GetComponent<AntController> ().properties = antproperties;
					ant.Add (tmp);
				}
			}
			foreach(Evenement e in g.evenements){
				foreach (GameObject tmp in ant) {
					if (e.o.GetType ().BaseType == typeof(Fourmi)) {
						if (tmp.GetComponent<AntController> ().properties.id == ((PersonnageAbstrait)(e.o)).id) {
							switch (e.ValeurEvenement) {
							case (int)FourmiliereConstante.typeEvenement.mouvementGauche:
								tmp.transform.position = new Vector3 (tmp.transform.position.x - 1, tmp.transform.position.y, 0);
								tmp.GetComponent<AntController> ().move ((int)direction.LEFT);
								break;
							case (int)FourmiliereConstante.typeEvenement.mouvementDroit:
								tmp.transform.position = new Vector3 (tmp.transform.position.x + 1, tmp.transform.position.y, 0);
								tmp.GetComponent<AntController> ().move ((int)direction.RIGHT);
								break;
							case (int)FourmiliereConstante.typeEvenement.mouvementBas:
								tmp.transform.position = new Vector3 (tmp.transform.position.x, tmp.transform.position.y - 1, 0);
								tmp.GetComponent<AntController> ().move ((int)direction.DOWN);
								break;
							case (int)FourmiliereConstante.typeEvenement.mouvementHaut:
								tmp.transform.position = new Vector3 (tmp.transform.position.x, tmp.transform.position.y + 1, 0);
								tmp.GetComponent<AntController> ().move ((int)direction.UP);
								break;
							case (int)FourmiliereConstante.typeEvenement.destruction:
								toRemoveAnt.Add (tmp);
								break;
							default:
								break;
							}
						}	
					} 
				}
				foreach(GameObject tmp in rice){
					if (e.o.GetType () == typeof(Nourriture)) {
						if(tmp != null)
						if (tmp.GetComponent<RiceController> ().riceId == ((Nourriture)(e.o)).id) {
							if (e.ValeurEvenement == (int)FourmiliereConstante.typeEvenement.destruction) {
								print ("destroyed");
								toRemoveRice.Add (tmp);
							}
						}
					}
				}
			}
			g.evenements = new List<Evenement>();
			foreach (GameObject t in toRemoveAnt) {
				Destroy (t);
				ant.Remove (t);
			}
			foreach (GameObject t in toRemoveRice) {
				Destroy (t);
				rice.Remove (t);
			}
		}
		//g.sauvegarde ();
	}

	void displayTimer(bool play){
		this.play = play;
	}

	void Reload(){
		startFrom = 0.0f;
		foreach(GameObject a in ant){
			Destroy (a);
		}
		ant.Clear ();
		Start ();
	}
}
