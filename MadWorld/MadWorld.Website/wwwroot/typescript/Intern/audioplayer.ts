import { ApplicationHTML } from '../base/application-html';

namespace AudioManager {
    class AudioPlayer {
        private Name: string = "";
        private Player: HTMLAudioElement = null;

        public Init(name: string) {
            this.Name = name;
            console.log(name);
            this.Player = ApplicationHTML.DocumentManager.GetElementByID<HTMLAudioElement>(this.Name);
            console.log(this.Player);
        }

        public Play() {
            this.Player.play();
        }
    }

    export function Load() {
        window["AudioPlayer"] = new AudioPlayer();
    }
}

AudioManager.Load();
