using UnityEngine;
using System.Collections;

/**
 * A Generic AI Component. Each AI component should extend this
 * class.
 * @author Christian Gunderman
 * @author cdg46
 */
public interface AIComponent {
	void Sense();
	void Think(EntityInterface npcInterface);
	bool Act(EntityInterface npcInterface);
}
