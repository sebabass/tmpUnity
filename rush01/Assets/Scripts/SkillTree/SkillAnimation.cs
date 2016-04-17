using UnityEngine;
using System.Collections;

public enum initPositionOn {
	player,positionBellow,gameobjectPositionBellow,camera,mouse
}

public class SkillAnimation : MonoBehaviour {

	[SerializeField] protected		float				_duration = 5f;
	[SerializeField] protected		GameObject			_annimationParticule;
	[SerializeField] public 		initPositionOn	 	_positionOn;
	[SerializeField] protected 		Vector3			 	_position;
	[SerializeField] protected 		GameObject			_positionGameObject;


	public void					instantiateAnimation() {
		Vector3 initPosition = this.getInstantiatePosition();

		if ( initPosition == Vector3.zero ) {
			this._instantiateAnimation(  );
			return ;
		}
		this._instantiateAnimation( initPosition );
	}

	private	void				_instantiateAnimation( Vector3 position ) {
		if ( this._annimationParticule == null )
			return ;

		GameObject anim = (GameObject)GameObject.Instantiate( this._annimationParticule, position, transform.localRotation );
		anim.AddComponent<autoDestruct>().expiration = this._duration;
	}

	private	void				_instantiateAnimation( ) {
		if ( this._annimationParticule == null )
			return ;

		GameObject anim = GameObject.Instantiate( this._annimationParticule );
		anim.AddComponent<autoDestruct>();
	}

	protected Vector3			getInstantiatePosition() {
		if ( this._positionOn == initPositionOn.player )
			return GameManager.gm.player.transform.position; // Get Player Position
		else if ( this._positionOn == initPositionOn.positionBellow )
				return this._position;
		else if ( this._positionOn == initPositionOn.gameobjectPositionBellow )
				return this._positionGameObject.transform.position;
		else if ( this._positionOn == initPositionOn.camera )
				return Camera.main.transform.position;
		else if ( this._positionOn == initPositionOn.mouse ) {
			RaycastHit hit;
			Ray rayPos; rayPos = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (rayPos, out hit, 100)) {
				return hit.point;
			}
			return Vector3.zero;
		}
		return Vector3.zero;
	}
}
