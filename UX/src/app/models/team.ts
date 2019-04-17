import { JsonProperty } from './mapUtils';

export class Team
{
    @JsonProperty('id')
    public id: number;
    @JsonProperty('name')
    public name: string;
}