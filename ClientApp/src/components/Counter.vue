<template>
  <div>
    <p>Current count (Vuex):
      <strong>{{ currentCount }}</strong>
    </p>
    <v-btn color="info" @click.prevent="increment">Increment</v-btn>
    <v-btn color="info" @click.prevent="reset">Reset</v-btn>
  </div>
</template>

<script lang="ts">
import { State, Action, Getter } from 'vuex-class';
import { Component, Prop, Vue } from 'vue-property-decorator';
const namespace: string = 'counter';

@Component
export default class Counter extends Vue {
  @Getter('currentCount', { namespace })
  private currentCount!: number;
  @Action('increment', { namespace })
  private incrementCounter: any;
  @Action('reset', { namespace })
  private resetCounter: any;

  private increment() {
    this.incrementCounter();
  }
  private reset() {
    this.resetCounter();
  }
}
</script>
