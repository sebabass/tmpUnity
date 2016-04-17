using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public abstract class SkillInformations : MonoBehaviour {
	[SerializeField]  protected		string			_name;
	[SerializeField]  protected		Image			_enable;
	[SerializeField]  protected		Image			_disable;

	[SerializeField] protected		int				_treeIndex;
	[SerializeField] protected		int				_treePosition;


	public abstract		bool		isOwned();
	public abstract		int			getMaxLevel();
	public abstract		int			getLevel();

	public				string		getName() {
		return this._name;
	}

	public				Image		getSkillImage() {
		if ( this.isOwned() == false ) {
			return this._disable;
		}
		float alpha = (( 0.5f / this.getMaxLevel()) * this.getLevel()) + 0.5f;
		Color color = this._enable.color;

		color.a = alpha;
		this._enable.color = color;
		return this._enable;
	}


	public void 					setTreeIndex( int index ) { this._treeIndex = index; }
	public int	 					getTreeIndex( ) { return this._treeIndex; }

	public void 					setTreePos( int pos ) { this._treePosition = pos; }
	public int	 					getTreePos( ) { return this._treePosition; }
}
