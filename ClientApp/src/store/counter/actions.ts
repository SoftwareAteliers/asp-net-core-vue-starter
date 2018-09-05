import { ActionTree } from 'vuex';
import axios from 'axios';
import { CounterState } from './types';
import { RootState } from '../types';

export const actions: ActionTree<CounterState, RootState> = {
  increment({ commit }): any {
    commit('incrementCounter');
  },
  reset({ commit }): any {
    commit('resetCounter');
  },
};
