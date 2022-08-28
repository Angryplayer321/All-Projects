using System.Collections;
using System.Collections.Generic;


public interface ICommand
{
	public void Execute();

	public void Undo();

	public float ReturnExecutionTime();
}
