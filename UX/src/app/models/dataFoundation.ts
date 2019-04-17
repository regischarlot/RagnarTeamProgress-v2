import { Runner } from './runner';
import { LegRunner } from './legRunner';
import { Pair } from './pair';
import { Exchange } from './exchange';
import { Team } from './team';

export class DataFoundation
{
	public runners: Runner[];
	public legRunners: LegRunner[];
	public runnerTypes: Pair[];
	public exchanges: Exchange[];
	public team: Team;
}



