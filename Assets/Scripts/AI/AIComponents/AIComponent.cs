using UnityEngine;
using System.Collections;

/**
 * A Generic AI Component. Each AI component should extend this
 * class.
 * @author Christian Gunderman
 * @author cdg46
 */
public interface AIComponent {

	/**
	 * Decide what to do next
	 */
	void Think(EntityInterface npcInterface);

	/**
	 * Perform one frame update.
	 */
	bool Act(EntityInterface npcInterface);
}
